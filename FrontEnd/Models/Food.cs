namespace FrontEnd.Models
{
    public class Food
    {
        private int id;
        private string name;
        private string img;
        private string price;

        public string Price { get { return price; } set { price = value; } }
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }       
        public string Image { get { return img; } set { img = value; } }
        public Food(int id, string name, string img, string price) {
            this.id = id;
            this.name = name; 
            this.img = img;
            this.price = price;
        } 

    }
}
