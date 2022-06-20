using Domain.Commands;
using Domain.Entities;
using Domain.Repository;
using Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers
{
    public class SubscriptionHandler :
        Notifiable<Notification>,
        IHandler<CreatePayPalSubscriptionCommand>
    {

        private readonly IStudentRepository _studentRepository;

        public SubscriptionHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new CommandResult(false, "Subscription invalid", command.Notifications);
            }

            AddNotifications(new Contract<SubscriptionHandler>()
                                .IsFalse(_studentRepository.EmailExists(command.Email), "Email")
                                .IsFalse(_studentRepository.DocumentExists(command.Document, command.DocumentType), "Document")
            );

            Name name = new Name(command.FirstName, command.LastName);
            Document document = new Document(command.DocumentType, command.Document);
            Email email = new Email(command.Email);
            Address address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            Subscription subscription = new Subscription(DateTime.Now.AddMonths(1));
            PayPalPayment payPalPayment = new PayPalPayment(
                                                command.PaidDate,
                                                command.ExpireDate,
                                                command.Total,
                                                command.TotalPaid,
                                                command.Payer,
                                                new Document(command.PayerDocumentType, command.PayerDocument),
                                                address,
                                                email,
                                                command.TransactionCode);

            subscription.AddPayment(payPalPayment);

            Student student = new Student(name, document, email);
            student.AddAddress(address);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payPalPayment);

            if (!IsValid)
                return new CommandResult(false, "Subscription invalid", Notifications);

            _studentRepository.CreateSubscription(student);

            return new CommandResult(true, "Subscription created", student);
        }
    }
}
