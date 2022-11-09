# Azure_Stream_Analytis

Azure IOT Hub로 받아오는 Dummy IOT Data를 Azure storage의 Container에 저장한다.
개발환경은 Windows11을 사용하며 Azure Virtual Machine을 이용하였다.


<img src="https://user-images.githubusercontent.com/107936957/200822198-7a37f290-7e7a-400f-9584-9bc7aa163779.jpg">

1.IOT Hub를 생성하고 장치탭에서 디바이스를 만든다 (설정은 Defalt)
2. DummyIOT로 날씨를 시간마다 받아오는 프로그램을 작성한다.
3. 프로그램으로 생성하는 날씨데이터를 Azrue Stream Analystics로 input한다.
4. Steam Analystics내 Qurly를 작성한다.
