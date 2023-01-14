using ProjectPractice.Models.VMs;

namespace ProjectPractice.Models.Extensions
{
	public static class Extensions
	{
		public static MemberIndexVM EntityToIndexVM(this Member source)
		{
			return new MemberIndexVM()
			{
				Id = source.Id,
				EmailAccount = source.EmailAccount,
				RealName = (source.RealName != null) ? source.RealName: string.Empty,
				Mobile = (source.Mobile != null) ? source.Mobile : string.Empty,
				// 城市是否這樣寫???
				City = (source.Address != null) ? source.Address.Substring(0, 3) : string.Empty,
				BirthOfDate = (source.BirthOfDate.HasValue) ? source.BirthOfDate.Value.ToString("yyyy-MM-dd") : string.Empty,
			};
		}

		public static BlackListVM EntityToBlackVM(this Member source)
		{
			return new BlackListVM()
			{
				Id = source.Id,
				EmailAccount = source.EmailAccount,
				RealName = source.RealName
			};
		}
	}
}
