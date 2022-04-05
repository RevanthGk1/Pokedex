namespace Pokedex.Models
{
    /// <summary>
    /// The base class for API resources that have a name property
    /// </summary>
    public abstract class NamedApiResource : ResourceBase
    {
        /// <summary>
        /// The name of this resource
        /// </summary>
        public abstract string Name { get; set; }
    }

    public class NamedApiResource<T> : UrlNavigation<T> where T : ResourceBase
    {
        /// <summary>
        /// The name of the referenced resource.
        /// </summary>
        public string Name { get; set; }
    }
}