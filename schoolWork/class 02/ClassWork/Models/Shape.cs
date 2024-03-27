namespace Models
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public float A {  get; set; }

        protected Shape(string name, float a)
        {
            Name = name;
            A = a;
        }
        public abstract float GetArea();
        
        public virtual string GetInfo()
        {
            return $"{Name}: {GetArea()}";
        }
    }
}
