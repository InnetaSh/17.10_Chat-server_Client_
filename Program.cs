




using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;



//----------------------------1-------------------------------------------------------------

//Базовое клиент-серверное приложение
//Задача: Написать простое клиент-серверное приложение, где клиент отправляет сообщение серверу, а сервер отвечает.
//Описание: Клиент отправляет строку текста на сервер, сервер получает её и отправляет клиенту сообщение, подтверждающее получение: "Сообщение получено".
//Усложнение: Добавь проверку, что сообщение не пустое, и если оно пустое, сервер отправляет ошибку.


//TcpClient tcpClient = new TcpClient("127.0.0.1", 13000);

//if (tcpClient.Connected)
//{
//    Console.WriteLine($"Подключение с {tcpClient.Client.RemoteEndPoint} установлено {DateTime.Now}");
//    Console.WriteLine("Введите сообщение:");
//    string message = Console.ReadLine();
//    if (String.IsNullOrEmpty(message))
//    { message = " "; }
//    byte[] requestData = Encoding.UTF8.GetBytes(message);

//    var stream = tcpClient.GetStream();

//    await stream.WriteAsync(requestData);
//    Console.WriteLine("Сообщение отправлено");




//    byte[] responseBuffer = new byte[1024];
//    int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
//    var responseMessage = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
//    Console.WriteLine($"Ответ от сервера: {responseMessage}");
//}
//else
//    Console.WriteLine("Не удалось подключиться");




//----------------------------2-------------------------------------------------------------

//Эхо - сервер
//Задача: Написать эхо-сервер, который получает сообщения от клиента и возвращает их обратно.
//Описание: Клиент отправляет строку серверу, сервер возвращает то же сообщение. Клиент должен вводить сообщения до тех пор, пока не отправит "exit", после чего соединение должно быть закрыто.
//Усложнение: Добавь ограничение на количество отправленных сообщений (например, максимум 5 сообщений за одну сессию).

//try
//{
//    TcpClient tcpClient = new TcpClient("127.0.0.1", 8888);

//    if (tcpClient.Connected)
//    {
//        int count = 0;
//        bool flag = true;
//        var stream = tcpClient.GetStream();
//        Console.WriteLine($"Подключение с {tcpClient.Client.RemoteEndPoint} установлено {DateTime.Now}");

//        while (count < 5)
//        {

//            Console.WriteLine("Введите сообщение (или 'exit' для выхода):");
//            string message = Console.ReadLine();

//            if (message.Equals("exit", StringComparison.OrdinalIgnoreCase))
//            {
//                break;
//            }
//            if (String.IsNullOrEmpty(message)) { message = " "; }


//            byte[] requestData = Encoding.UTF8.GetBytes(message);

//            await stream.WriteAsync(requestData);
//            Console.WriteLine("Сообщение отправлено");




//            byte[]  responseBuffer = new byte[1024];
//            int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
//            var responseMessage = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
//            Console.WriteLine($"Ответ от сервера: {responseMessage}");
//            count++;

//        }
//        Console.WriteLine("Сессия завершена. Максимальное количество сообщений отправлено.");
//    }
//    else
//        Console.WriteLine("Не удалось подключиться");
//}
//catch (SocketException se)
//{
//    Console.WriteLine($"Сетевое исключение: {se.Message}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Ошибка: {ex.Message}");

//}


//----------------------------3-------------------------------------------------------------

//Передача файлов по TCP
//Задача: Реализовать передачу файлов с клиента на сервер.
//Описание: Клиент отправляет файл серверу. Сервер принимает файл и сохраняет его на диске с указанием времени и даты получения.
//Усложнение: Добавь возможность передачи файлов разных типов и размеров, 
//    включая проверку целостности данных с помощью контрольной суммы (например, MD5).



//string filePath = "test.txt";
//try
//{
//    using (TcpClient client = new TcpClient("127.0.0.1", 8888))
//    using (NetworkStream stream = client.GetStream())
//    using (BinaryWriter writer = new BinaryWriter(stream))
//    {
//        DateTime now = DateTime.Now;
//        string dateString = now.ToString("yyyy-MM-dd HH:mm:ss");
//        byte[] requestData = Encoding.UTF8.GetBytes(dateString);
//        stream.Write(requestData);


//        string fileName = Path.GetFileName(filePath);
//        byte[] requestName = Encoding.UTF8.GetBytes(fileName);
//        stream.Write(requestName);


//        byte[] fileData = File.ReadAllBytes(filePath);


//        writer.Write(fileData);

//        byte[] md5Hash = getFileHash(filePath);
//        stream.Write(md5Hash);


//        Console.WriteLine($"Файл '{fileName}' успешно отправлен {now}.");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Ошибка: {ex.Message}");

//}

// static byte[] getFileHash(string path)
//{
//    using (MD5 md5 = MD5.Create())
//    {
//        return md5.ComputeHash(File.OpenRead(path));
//    }
//}






//----------------------------4-------------------------------------------------------------


//Тестирование производительности TCP-соединения
//Задача: Написать программу для тестирования скорости передачи данных через TCP.
//Описание: Клиент отправляет большой объём данных (например, файл) на сервер, а сервер измеряет время передачи и рассчитывает скорость.
//Усложнение: Добавь возможность тестирования скорости в двух направлениях (сервер-клиент и клиент-сервер).



//string filePath = "test.txt";
//try
//{
//    using (TcpClient client = new TcpClient("127.0.0.1", 8888))
//    using (NetworkStream stream = client.GetStream())
//    using (BinaryWriter writer = new BinaryWriter(stream))
//    {
//        DateTime now = DateTime.Now;
//        string dateString = now.ToString("yyyy-MM-dd HH:mm:ss");
//        byte[] requestData = Encoding.UTF8.GetBytes(dateString);
//        stream.Write(requestData);


//        string fileName = Path.GetFileName(filePath);
//        byte[] requestName = Encoding.UTF8.GetBytes(fileName);
//        stream.Write(requestName);


//        byte[] fileData = File.ReadAllBytes(filePath);


//        DateTime startTime = DateTime.Now;
//        writer.Write(fileData);

//        Console.WriteLine($"Файл успешно отправлен");


//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Ошибка: {ex.Message}");

//}






//----------------------------5-------------------------------------------------------------
//Клиент - серверная система запросов и ответов
//Задача: Реализовать сервер, который может отвечать на запросы клиента, например, по времени, дате или другой простой информации.
//Описание: Клиент отправляет запрос "Время", сервер отвечает текущим временем. При запросе "Дата" сервер возвращает текущую дату. При запросе "exit" соединение закрывается.
//Усложнение: Реализуй поддержку нескольких команд и добавь команду, которая возвращает случайную цитату.

//var words = new string[] { "Время", "Дата" };

//using TcpClient tcpClient = new TcpClient();
//await tcpClient.ConnectAsync("127.0.0.1", 8888);
//var stream = tcpClient.GetStream();


//var response = new List<byte>();
//int bytesRead = 10; 
//foreach (var word in words)
//{

//    byte[] data = Encoding.UTF8.GetBytes(word + '\n');

//    await stream.WriteAsync(data);


//    while ((bytesRead = stream.ReadByte()) != '\n')
//    {

//        response.Add((byte)bytesRead);
//    }
//    var dataT = Encoding.UTF8.GetString(response.ToArray());
//    Console.WriteLine($"{word}: {dataT}");
//    response.Clear();

//    await Task.Delay(2000);
//}


//await stream.WriteAsync(Encoding.UTF8.GetBytes("exit\n"));









//----------------------------6-------------------------------------------------------------
////Средний уровень: Реализовать сервер, который может принимать несколько клиентов одновременно. Каждый клиент отправляет своё имя,
////а сервер возвращает приветственное сообщение "Привет, {имя}!" для каждого клиента.
////Цель: использование многопоточности для работы с несколькими клиентами.
////Результат: сервер должен обрабатывать несколько клиентов параллельно.


//var message = "Bob";
//using TcpClient tcpClient = new TcpClient();
//Console.WriteLine($"Клиент {message} запущен");
//await tcpClient.ConnectAsync("127.0.0.1", 13000);



//if (tcpClient.Connected)
//{
//    Console.WriteLine($"Подключение с {tcpClient.Client.RemoteEndPoint} установлено {DateTime.Now}");
//    byte[] requestData = Encoding.UTF8.GetBytes(message);

//    var stream = tcpClient.GetStream();

//    await stream.WriteAsync(requestData);
//    Console.WriteLine("Сообщение отправлено");




//    byte[] responseBuffer = new byte[1024];
//    int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
//    var responseMessage = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
//    Console.WriteLine($"Ответ от сервера: {responseMessage}");
//}
//else
//    Console.WriteLine("Не удалось подключиться");




//var message2 = "Sam";
//using TcpClient tcpClient2 = new TcpClient();
//Console.WriteLine($"Клиент {message} запущен");
//await tcpClient2.ConnectAsync("127.0.0.1", 13000);

//if (tcpClient2.Connected)
//{
//    Console.WriteLine($"Подключение с {tcpClient2.Client.RemoteEndPoint} установлено {DateTime.Now}");
//    byte[] requestData2 = Encoding.UTF8.GetBytes(message2);

//    var stream = tcpClient2.GetStream();

//    await stream.WriteAsync(requestData2);
//    Console.WriteLine("Сообщение отправлено");
//}
//else
//    Console.WriteLine("Не удалось подключиться");








//----------------------------7-------------------------------------------------------------
//Реализация протокола передачи сообщений с подтверждением
//Задача: Написать приложение, в котором клиент отправляет данные, а сервер должен отправить подтверждение о получении каждого пакета.
//Описание: Клиент отправляет сообщение, сервер его получает и отвечает "ACK". Если клиент не получил ответ в течение определённого времени, он должен повторить отправку.
//Усложнение: Добавь возможность отправки нескольких сообщений подряд с проверкой получения каждого.

//try
//{
//    TcpClient tcpClient = new TcpClient("127.0.0.1", 8888);

//    if (tcpClient.Connected)
//    {

//        var stream = tcpClient.GetStream();
//        Console.WriteLine($"Подключение с {tcpClient.Client.RemoteEndPoint} установлено {DateTime.Now}");



//        string[] messages = { "Сообщение 1", "Сообщение 2", "Сообщение 3" };
//        foreach (var message in messages)
//        {
//            byte[] data = Encoding.UTF8.GetBytes(message);
//            int count = 0;
//            bool ackReceived = false;

//            while (count < 3 && !ackReceived)
//            {
//                count++;
//                await stream.WriteAsync(data, 0, data.Length);
//                Console.WriteLine($"Отправлено: '{message}'");


//                var buffer = new byte[1024];
//                stream.ReadTimeout = 100; 

//                try
//                {
//                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
//                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
//                    if (response == "ACK")
//                    {
//                        Console.WriteLine($"ACK получен для: '{message}'");
//                        ackReceived = true;
//                    }
//                }
//                catch (Exception)
//                {
//                    Console.WriteLine($"Нет ACK для: '{message}', повторная отправка...");
//                    Thread.Sleep(500);
//                }
//            }

//            if (!ackReceived)
//            {
//                Console.WriteLine($"Сообщение '{message}' не было подтверждено после {count} попыток.");
//            }
//        }

//        Console.WriteLine("Все сообщения отправлены.");
//    }
//    else
//        Console.WriteLine("Не удалось подключиться");
//}
//catch (SocketException se)
//{
//    Console.WriteLine($"Сетевое исключение: {se.Message}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Ошибка: {ex.Message}");

//}
