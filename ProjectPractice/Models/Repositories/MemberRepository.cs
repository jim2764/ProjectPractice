using ProjectPractice.Models.DTOs;
using ProjectPractice.Models.Extensions;

namespace ProjectPractice.Models.Repositories
{
    public class MemberRepository
    {
		private readonly PracticeContext _context;

		public MemberRepository(PracticeContext context)
		{
			_context = context;
		}

		public IEnumerable<MemberDTO> GetAll()
		{
			var members = _context.Members;

			return members.Select(x => x.EntityToDTO());
		}

		public IEnumerable<MemberDTO> GetSomeAddress(string selectCity)
		{
			var members = _context.Members.Where(x => x.Address != null && x.Address.Contains(selectCity));

			return members.Select(x => x.EntityToDTO());
		}

		public IEnumerable<MemberDTO> GetSomeAccount(string account)
		{
			var members = _context.Members.Where(x => x.EmailAccount != null && x.EmailAccount.Contains(account));

			return members.Select(x => x.EntityToDTO());
		}

		public IEnumerable<MemberDTO> GetSomeAccountAndAddress(string account, string selectCity)
		{
			var members = _context.Members.Where(x => x.EmailAccount != null && x.EmailAccount.Contains(account) && x.Address.Contains(selectCity));

			return members.Select(x => x.EntityToDTO());
		}
	}
}
