namespace Stolarczyk.Katalog.DAO
{
    using Stolarczyk.Katalog.INTERFACES;

    public class Manufacturer : IManufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}