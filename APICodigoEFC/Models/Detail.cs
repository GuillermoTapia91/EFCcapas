namespace APICodigoEFC.Models
{
    public class Detail
    {
        public int DetailID { get; set; }
        public bool IsActive { get; set; }


        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
