using StructureMap;
using System.Web.Http.Dependencies;

namespace Newsletter.Web.IoC
{
    public class StructureMapDependencyResolver : StructureMapDependencyScope, IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = this.container.GetNestedContainer();
            return new StructureMapDependencyScope(childContainer);
        }
    }
}