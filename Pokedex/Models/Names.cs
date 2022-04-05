namespace Pokedex.Models
{
    /// <summary>
    /// A name with language information
    /// </summary>
    public class Names
    {
        /// <summary>
        /// The localized name for an API resource in a specific language.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        public NamedApiResource<Language> Language { get; set; }
    }
}