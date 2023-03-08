# EasySignalRServer :+1:
SignalR로 만든 서버 &amp; 테스트 클라이언트

## :page_facing_up: 개요 

<br/>
 
1. 💻RSignalRServer : SignalR(WebSocket)을 사용한 실시간 통신 서버
2. 🏃Testclient : 실시간 서버에 붙을 테스트 클라이언트 

<br/>

* SignalR 서버, 테스트 클라이언트 간소화하여 필수 기능을 구현

* 내부 동작을 위한 개별 라이브러리 있음

* Log - RLoger : Log4net을 사용한 로그 프로그램

<br/>

### :exclamation: 현재 버전 설명

<br/>

|날짜|version|설명|
|------|---|---|
|2023-03-08|1|기본 채팅만 가능한 서버와 클라이언트 

<br/>  

### :exclamation: 추가 예정 사항

<br/>

1. client state 분리 
2. chatting room과 채널 분리 

<br/>  
  
-----

<br/>

## :books: 공통
<br/>

- C#을 사용 하여 개발

- .net framework 4.8로 개발

- 모든 서버는 Windows에서 정상 작동

<br/>

-----

<br/>

### :pencil2: 기능 

-----

<br>

## :computer: RSignalRServer

<br>

### :game_die: RSignalRServer ?

<br/>

- SignalR을 사용하여 '실시간' 통신이 가능한 서버, Selfhost하여 실행. 

<br/>

### :pencil2: 기능 

<br>

|URI|설명|
|---|---|
|/SendMessage|채팅서버로 메시지 발신, 같은 그룹에 포함된 모든 유저는 해당 메시지 받음 
<br>

-----

<br>

## :running: TestClient

<br>

### :game_die: TestClient ?

<br/>

- SignalR client를 사용하는 console Test client 프로그램. 

<br/>

### :pencil2: 기능 

<br>

    [연결]
    - 서버에 연결 요청

    [메시지 송신]
    - 원하는 메시지를 연결된 서버로 보냄

    [연결종료]
    - 연결 종료 요청을 하여 서버로부터 정상 종료 

<br>

-----
