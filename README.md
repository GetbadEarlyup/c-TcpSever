# c-TcpSever
基于winfrom的TCPseverDemo

![image](https://github.com/user-attachments/assets/fc2364f1-0023-4060-8f14-32b94f42a426)

可使用此工程文件学习TCP相关知识，或是免去人员一些编码的问题
也可用此工程进行网络测试
其中：
bodys 就是传输进来的数据了
一个正常的tcp网络传世应当遵循：
包头 4byte 【告知包体大小】
包体 根据包头告知的大小进行创建【本代码采用了这种】

标准协议应当为
包头 4byte 【告知包体大小】
协议 4byte 【传输数据命令】
加密 【根据自己的要求定】 一般为 4byte 或 8byte
包体 根据包头告知的大小进行创建

CSDN:作孽就得先起床
