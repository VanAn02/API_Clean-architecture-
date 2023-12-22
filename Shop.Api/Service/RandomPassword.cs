namespace Shop.Api.Service
{
    public class RandomPassword
    {
        public string GenerateCode()
        {
            Random random = new Random();
            int code = random.Next(1000, 9999);

            return code.ToString();
        }
    }
}
