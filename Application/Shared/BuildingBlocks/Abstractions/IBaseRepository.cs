namespace BuildingBlocks.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        //public GenericContext<T> Context() => new GenericContext<T>();

        //public T Select(int id) => Context().Items.Single(x => x.Id == id);

        //public IQueryable<T> Select() => Context().Items;

        //public void Insert(T item)
        //{
        //    var context = Context();
        //    context.Items.Add(item);
        //    context.SaveChanges();
        //}

        //public void Update(T item)
        //{
        //    var context = Context();
        //    context.Items.Attach(item);
        //    context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var context = Context();
        //    var item = context.Items.Single(x => x.Id == id);
        //    context.Items.Remove(item);
        //    context.SaveChanges();
        //}
    }
}


