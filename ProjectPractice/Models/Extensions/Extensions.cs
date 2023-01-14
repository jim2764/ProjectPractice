using ProjectPractice.Models.DTOs;
using ProjectPractice.Models.VMs;

namespace ProjectPractice.Models.Extensions
{
	public static class Extensions
	{
		public static MemberIndexVM DTOToIndexVM(this MemberDTO source)
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

		public static MemberDTO EntityToDTO(this Member source)
		{
			return new MemberDTO()
			{
				Id = source.Id,
				EmailAccount = source.EmailAccount,
				EncryptedPassword = source.EncryptedPassword,
				RealName = source.RealName,
				NickName = source.NickName,
				BirthOfDate = source.BirthOfDate,
				Mobile = source.Mobile,
				Address = source.Address,
				PhotoSticker = source.PhotoSticker,
				About = source.About,
				ConfirmCode = source.ConfirmCode,
				IsConfirmed = source.IsConfirmed,
				IsInBlackList = source.IsInBlackList
			};
		}
	}
}
