using System;
using System.Collections.Generic;
using System.Linq;

namespace ImmutableClass
{
    public sealed class Email
    {
        // subject of the message
        public string Subject { get; }
        // from whom the message was sent
        public string Sender { get; }
        // text of the email message
        public string Message { get; }
        // list to whom the messages were sent
        public IReadOnlyList<string> RecipientList { get; }

        public Email(string subject, string sender, string message,
            string recipient)
        {
            Subject = subject;
            Sender = sender;
            Message = message;
            RecipientList = new List<string>() { recipient };
        }

        private Email(string subject, string sender, string message,
            List<string> recipients)
        {
            Subject = subject;
            Sender = sender;
            Message = message;
            RecipientList = recipients;
        }

        public Email AddNewRecipient(string recipient)
        {
            return new Email(
                this.Subject,
                this.Sender,
                this.Message,
                new List<string>().Concat(RecipientList).Append(recipient)
                .ToList()
                );
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Email);
        }

        private bool Equals(Email email)
        {
            return email != null
                && (String.Compare(this.Subject, email.Subject) == 0)
                && (String.Compare(this.Sender, email.Sender) == 0)
                && (String.Compare(this.Message, email.Message) == 0)
                && (this.RecipientList).SequenceEqual(email.RecipientList);
        }

        public override int GetHashCode()
        {
            return Subject.GetHashCode() ^
                Sender.GetHashCode() ^
                Message.GetHashCode() ^
                RecipientList.GetHashCode();
        }
    }

    public class Program
    {
        public static void Main()
        {
            Email email = new Email("recipient@mail.ru", "sender@mail.ru", "my new message for you", "You need to check your phone!");
            Email email2 = new Email("no_name_recipient@mail.ru", "sender@mail.ru", "my new message for you", "You need to check your phone!");

            Console.WriteLine(email2.GetHashCode());
            email2.AddNewRecipient("second_recipient@mail.ru");
            Console.WriteLine(email2.GetHashCode());
        }
    }
}
