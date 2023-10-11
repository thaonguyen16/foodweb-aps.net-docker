namespace BannerAPI.Models
{
    public class Banner
    {
        private int id;
        private string name;
        private string img;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }       
        public string Image { get { return img; } set { img = value; } }
        public Banner(int id, string name, string img) {
            this.id = id;
            this.name = name; 
            this.img = img;
        } 

    }
}
