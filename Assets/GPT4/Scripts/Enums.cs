namespace Enums {
	public enum ChatModels
	{
		GPT_3_5_TURBO,
		GPT_4
	}
	
	public enum RequestMethod {
		POST = 0,
		GET = 1,
		PUT = 2,
		DELETE = 3
	}
	
	public enum HttpStatus : int {
		ReadyToReceive = -1,
		AppError = 0,
		IsOk = 200,
		Created = 201,
        
		Unauthorized = 401,
		Forbidden = 403,
		NotFound = 404,
		InternalServerError = 500,
		BadGateway = 502,
		ServiceUnavailable = 503,
	}
}