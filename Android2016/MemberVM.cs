using System;
using Newtonsoft.Json;

namespace Android2016
{
	public class MemberVM 
	{
		public MemberVM()
		{
			this.FirstName = string.Empty;
			this.LastName = string.Empty;
			this.TelephoneNumber = string.Empty;
			this.Address = string.Empty;
		}

		public MemberVM(MemberVM vm)
		{
			this.FirstName = vm.FirstName;
			this.LastName = vm.LastName;
			this.TelephoneNumber = vm.TelephoneNumber;
			this.Address = vm.Address;
		}

		[JsonProperty("MemberId")]
		public int MemberId
		{
			get;
			set;
		}
		[JsonProperty("UserId")]
		public int UserId
		{
			get;
			set;
		}
		[JsonProperty("FirstName")]
		public string FirstName
		{
			get;
			set;
		}
		[JsonProperty("LastName")]
		public string LastName
		{
			get;
			set;
		}
		[JsonProperty("TelephoneNumber")]
		public string TelephoneNumber
		{
			get;
			set;
		}
		[JsonProperty("Address")]
		public string Address
		{
			get;
			set;
		}
		[JsonProperty("isActive")]
		public bool? isActive
		{
			get;
			set;
		}
	}
}
