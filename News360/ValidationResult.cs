namespace News360 {
	public class ValidationResult {
		private readonly bool _isValid;
		private readonly string _errorMessage;

		private ValidationResult(bool isValid, string errorMessage)
		{
			_isValid = isValid;
			_errorMessage = errorMessage;
		}

		public bool IsValid
		{
			get { return _isValid; }
		}

		public string ErrorMessage
		{
			get { return _errorMessage; }
		}

		public static ValidationResult Succes()
		{
			return new ValidationResult(true, string.Empty);
		}

		public static ValidationResult Error(string errorMessage)
		{
			return new ValidationResult(false, errorMessage);
		}
	}
}