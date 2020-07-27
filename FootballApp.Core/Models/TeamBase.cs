using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Models {
	public abstract class TeamBase {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TeamId { get; set; }
		public string Name { get; set; }
		public string AltName { get; set; }
	}
}
