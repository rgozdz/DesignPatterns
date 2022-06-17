namespace DesignPatterns.Structural
{
    public class ShapeBridge
    {
        public interface IRenderer
        {
            string WhatToReadAs { get; }
        }

        public abstract class Shape
        {
            protected Shape(IRenderer renderer)
            {
                Renderer = renderer;
            }

            public IRenderer Renderer { get; set; }
            public string Name { get; set; }
        }

        public class Triangle : Shape
        {
            public Triangle(IRenderer renderer) : base(renderer)
            {
                Name = "Triangle";
            }

            public override string ToString() => $"Drawing {Name} as {Renderer.WhatToReadAs}";
        }

        public class Square : Shape
        {
            public Square(IRenderer renderer) : base(renderer)
            {
                Name = "Square";
            }

            public override string ToString() => $"Drawing {Name} as {Renderer.WhatToReadAs}";
        }

        public class VectorRenderer : IRenderer
        {
            public VectorRenderer()
            {
                WhatToReadAs = "lines";
            }

            public string WhatToReadAs { get; }
        }


        public class RasterRenderer : IRenderer
        {
            public RasterRenderer()
            {
                WhatToReadAs = "pixels";
            }

            public string WhatToReadAs { get; }
        }
    }
}
