using System;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
	public class Comment
	{
		// Props
		public int CommentId { get; set; }
		public ApplicationUser MyProperty { get; set; }
		public string Message { get; set; }
		public DateTime CommentDate { get; set; }
		public int Likes { get; set; }
		public int Dislikes { get; set; }

		// Comment Constructor
		public Comment()
		{
			CommentDate = DateTime.Now;
		}

		// Return percentage of likes to total votes
		public double LikeRatio()
		{
			return Likes / (Likes + Dislikes) * 100;
		}
	}
}