# GMAP.NET GIS Map Test

### Goal
> Ironwall에 적용하기 위한 MAP을 GIS 서비스를 활용한 MAP을 제공하도록 한다.

<hr>
### Update Date: 2023/02/24  

* Version : -  

* 개발 내역  
    
      1) Nuget Example 을 활용하여 Non-MVVM으로 실행 샘플을 구현하여 테스트하였다.  
      2) GMAP.NET의 기능을 확인하고 점검하였다.  
      3) 가장 기본적인 라이브러리 임포팅을 시행하였다.  
      
    ```
    <packages>
        <package id="EntityFramework" version="6.4.4" targetFramework="net48" />
        <package id="GMap.NET.Core" version="2.1.7" targetFramework="net48" />
        <package id="GMap.NET.Windows" version="2.1.7" targetFramework="net48" />
        <package id="GMap.NET.WinForms" version="2.1.7" targetFramework="net48" />
        <package id="GMap.NET.WinPresentation" version="2.1.7" targetFramework="net48" />
        <package id="Newtonsoft.Json" version="13.0.2" targetFramework="net48" />
        <package id="Stub.System.Data.SQLite.Core.NetFramework" version="1.0.117.0" targetFramework="net48" />
        <package id="System.Data.SqlClient" version="4.8.5" targetFramework="net48" />
        <package id="System.Data.SQLite" version="1.0.117.0" targetFramework="net48" />
        <package id="System.Data.SQLite.Core" version="1.0.117.0" targetFramework="net48" />
        <package id="System.Data.SQLite.EF6" version="1.0.117.0" targetFramework="net48" />
        <package id="System.Data.SQLite.Linq" version="1.0.117.0" targetFramework="net48" />
        <package id="System.Security.Principal.Windows" version="5.0.0" targetFramework="net48" />
    </packages>
    ```  
<hr>
### Update Date: 2023/02/27  

* Version : v1.0.0  

* 개발 내역  
    
      1) 가장 기본적인 BaseLine을 구현하였다.  
      2) 일부 동작상 에러를 디버깅하였다.
         a) 종료 후에 프로세스가 처리되지 않는 문제로 Pending되는 문제를 해결하였다.  
      3) Symbol에 사용되는 기본적인 CustomControl을 구성하여 Gis Map상 오브젝트로 설정하였다.  
         a) 맵상에 시현되는 오브젝트의 종류에 때라 다양한 이벤트가 시현되고, 요구되는 장비에 따라 다양한 오브젝트가 표현될 수 있어야 됨.   
      4) 맵의 Scale에 따라 ProgressBar를 연동하여 데이터 변동을 확인하였다. (일부 버그가 확인되어 디버깅이 필요함.)  
         a) 맵의 스케일 변경에 따른 UI인지 및 제어를 위한 컨트롤 구현  
         b) 실제 스케일과 동기적으로 움직임이 구현되어야 함  
      5) CustomControl의 Datatrigger로 애니메이션 동작 여부를 정하기 위해서 DependencyProperty 설정하였으나 작동 안함.  
         a) 다양한 이벤트(탐지, 고장 등)의 대응하는 UI 이벤트 시현을 위한 개발  
         b) 

<hr>
