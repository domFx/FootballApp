using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Models {
	public abstract class CountryBase {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CountryId { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
	}
}
