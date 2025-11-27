namespace drive.Services.BaseAPI {
    internal interface IApiService {
        HttpClient client { get; set; }

        /// <summary>
        /// Выполняет HTTP запрос по указанному типу
        /// Принимает uri в ввиде: api/v...
        /// Отравляет <typeparamref name="TRequest"/> в теле запроса
        /// </summary>
        /// <typeparam name="TRequest">Отправляемый DTO Request файл</typeparam>
        /// <typeparam name="TResponse">Возвращемый DTO Response файл</typeparam>
        /// <param name="method">HttpMethod параметр</param>
        /// <param name="uri">Путь без хоста</param>
        /// <param name="request">DTO Request файл</param>
        /// <returns>Сериализованный объект <typeparamref name="TResponse"/></returns>
        public Task<TResponse> HttpAsync<TRequest, TResponse>(HttpMethod method, string uri, TRequest? request);

        /*
         * ApiService будет использоваться как базовый класс
         * для всех сервисов работающих с апи, а IApiService является его интерфейсом
         * позже необходимо дополнить этот интерфейс и ApiService методом - WebSocketAsync
         * т.к верификации на апи требует такого типа подключения
         */
    }
}
