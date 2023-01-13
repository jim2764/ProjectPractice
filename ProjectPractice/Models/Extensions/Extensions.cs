using ProjectPractice.Models.VMs;

namespace ProjectPractice.Models.Extensions
{
	public static class Extensions
	{
		public static MemberIndexVM EntityToVM(this Member source)
		{
			return new MemberIndexVM()
			{
				Id = source.Id,
				EmailAccount = source.EmailAccount,
				RealName = source.RealName,
				Mobile = source.Mobile,
				Address = source.Address
			};
		}
	}
}
