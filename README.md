# Azure_Stream_Analytis

Azure IOT Hub로 받아오는 Dummy IOT Data를 Azure storage의 Container에 저장한다.
개발환경은 Windows11을 사용하며 Azure Virtual Machine을 이용하였다.


<img src="https://user-images.githubusercontent.com/107936957/200822198-7a37f290-7e7a-400f-9584-9bc7aa163779.jpg">

1. IOT Hub를 생성하고 장치탭에서 디바이스를 만든다 (설정은 Defalt)\
2. Storage의 Container를 생성한다.
3. DummyIOT로 날씨를 시간마다 받아오는 프로그램을 작성한다.\
4. 프로그램으로 생성하는 날씨데이터를 Azrue Stream Analystics로 input한다.\
 ![스크린샷 2022-11-09 오후 8 56 00](https://user-images.githubusercontent.com/107936957/200824175-b7fc6c87-41a3-4f75-aebd-dc85df35bf26.png)
 Qurly로 데이터의 입출력 테스트를 해볼 수 있다.
5. Steam Analystics내 Qurly를 작성한다. 이때 양쪽으로 데이터를 보낼 수 있도록 Qurly를 작성한다.\
6. 한쪽은 Database로, 한쪽은 container로 데이터를 보낸다.
