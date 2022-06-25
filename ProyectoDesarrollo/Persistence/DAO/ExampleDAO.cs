using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO
{
    public class ExampleDAO
    {
        public readonly DataBaseContext DbContext;

        public ExampleDAO(DataBaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Example(int id)
        {
            //using context go to line by id
        }
    }
}
