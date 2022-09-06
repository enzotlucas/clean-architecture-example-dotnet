namespace Exemplo.CRUD.Core.ValueObjects
{
    public class Category
    {
        public string Name { get; private set; }
        public int Code { get; private set; }

        public Category(string name)
        {
            Name = name;
            Code = new Random().Next();
        }
    }
}
