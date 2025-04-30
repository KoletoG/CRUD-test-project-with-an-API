namespace CRUD_test_project_with_an_API.Exceptions
{
    public class DbCustomException : Exception
    {
        public DbCustomException() : base("An error has occured with the I/O db operations.")  
        {

        }
    }
}
