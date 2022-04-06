namespace Pokedex.Models
{
    /// <summary>
    /// Pokemon is the processed/final response object from this Api.
    /// </summary>
    public class Pokemon : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.Pokemon-ID. 
        /// </summary>
        public override int Id { get; set; }
        
        /// <summary>
        /// The Name of the Pokemon.
        /// </summary>
        public override string Name { get; set; }
        
        /// <summary>
        /// The processed description of the Pokemon.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// IsLegendary .
        /// </summary>
        public bool IsLegendary { get; set; }

        /// <summary>
        /// Habitats are generally different terrain Pokémon can be found in but
        /// can also be areas designated for rare or legendary Pokémon.
        /// </summary>
        public string Habitat { get; set; }
    }
}
