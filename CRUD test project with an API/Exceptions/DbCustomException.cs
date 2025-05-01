namespace CRUD_test_project_with_an_API.Exceptions
{
    public class DbCustomException : Exception
    {
        // Custom exception to throw if an error with the I/O operations has occured
        public DbCustomException() : base("An error has occured with the I/O db operations.")  
        {

        }
    }
}
