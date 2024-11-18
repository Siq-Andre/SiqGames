namespace SiqGames.Database
{
    public class DAL<T> where T : class
    {
        protected readonly SiqGamesContext context;

        public DAL(SiqGamesContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Get()
        {
            return context.Set<T>().ToList();
        }

        public void Add(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Set<T>().Update(obj);
            context.SaveChanges();
        }

        public void Delete(T obj)
        {
            context.Set<T>().Remove(obj);
            context.SaveChanges();
        }

        public T? GetBy(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }
    }
}
