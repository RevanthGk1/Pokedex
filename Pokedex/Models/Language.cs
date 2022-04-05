namespace Pokedex.Models
{
    /// <summary>
    /// Languages for translations of API resource information.
    /// </summary>
    public class Language : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "language";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Whether or not the games are published in this language.
        /// </summary>
        public bool Official { get; set; }

        /// <summary>
        /// The two-letter code of the country where this language
        /// is spoken. Note that it is not unique.
        /// </summary>
        public string Iso639 { get; set; }

        /// <summary>
        /// The two-letter code of the language. Note that it is not
        /// unique.
        /// </summary>
        public string Iso3166 { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }
}