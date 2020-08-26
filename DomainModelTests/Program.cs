using System;
using ApplicationServices.Core;
using DomainModel.Core;

namespace DomainModelTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var confirmationString = new ConfirmSubscriptionEmail("even@mail.net", "default@mail.net", "a7972a50-0b7f-4278-babb-a65bcf010824");

            Console.WriteLine(confirmationString.Text);
        }
    }
}
