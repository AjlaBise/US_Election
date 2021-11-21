namespace US_Election.Dal.Database
{
    public class Exception
    {
        public int Id { get; set; }

        public string ErrorMessage { get; set; }

        public Exception()
        {
            ErrorMessage = "Please select correct format of the file!";
        }
    }
}