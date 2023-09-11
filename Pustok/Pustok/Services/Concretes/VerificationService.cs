using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pustok.Database;
using Pustok.Services.Abstracts;
using System.Text;

namespace Pustok.Services.Concretes
{
    public class VerificationService : IVerificationService
    {
        private readonly PustokDbContext _dbContext;
        private static Random random = new Random();
        private static HashSet<string> usedCodes = new HashSet<string>();

        public VerificationService(PustokDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GenerateProductCode()
        {
            const string prefix = "PRC";
            const int randomDigitsCount = 5;

            string productCode;

            do
            {
                string randomDigits = GenerateRandomDigits(randomDigitsCount);
                productCode = prefix + randomDigits;
            }
            while (IsProductCodeExists(productCode));

            
            MarkProductCodeAsUsed(productCode);

            return productCode;
        }

        private static string GenerateRandomDigits(int count)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                int randomNumber = random.Next(10);
                sb.Append(randomNumber);
            }

            return sb.ToString();
        }

        private bool IsProductCodeExists(string productCode)
        {
            return _dbContext.Products.Any(p => p.TrackingCode == productCode);
        }

        private void MarkProductCodeAsUsed(string productCode)
        {
            usedCodes.Add(productCode);
        }
    }

}
