using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Models {
	public abstract class CompetitionBase {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CompetitionId { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
	}
}
