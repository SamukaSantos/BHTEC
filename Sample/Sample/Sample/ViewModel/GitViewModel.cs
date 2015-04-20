using PropertyChanged;
using Sample.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModel
{
	[ImplementPropertyChanged]
	public class GitViewModel
	{
		#region Properties

		public GitService Service { get; private set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string Login { get; set; }

		#endregion

		#region Command

		public ICommand SubmitCommand
		{
			get 
			{ 
				return new Command(() => 
							{
								GetUser();
							}); 
			}
		}

		public void GetUser()
		{
			Service = new GitService ();

			Octokit.User user = Service.GetUserAsync(UserName);
			Email = user.Email;
			Login = user.Login; 
		}

		#endregion

		#region Constructor

		public GitViewModel()
		{
			Service = new GitService();
		}

		#endregion
	}
}
