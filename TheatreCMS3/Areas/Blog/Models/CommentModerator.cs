using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
	public class CommentModerator : ApplicationUser
	{
		// Props
		public int BanAppealsResolved { get; set; }
		public List<ApplicationUser> BannedUsers { get; set; }
	}
}