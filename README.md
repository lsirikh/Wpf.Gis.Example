# GMAP.NET GIS Map Test

### Goal
> Ironwall에 적용하기 위한 MAP을 GIS 서비스를 활용한 MAP을 제공하도록 한다.

<br>
<br>

#### GIS 시스템이 필요한 Requirement  

   1. 지정된 위치에 Map을 로드 할 수 있어야 한다. 또한, 오프라인 환경에서 제공할 수 있어야 한다.  
   2. 특정 지역의 맵을 로드할 수 있는 파일이 제공되거나 확보할 수 있어야 한다.
   3. 지정된 영역을 벗어나지 않도록 제한 할 수 있어야 한다.  
   4. 지정된 배율을 조정할 수 있도록 범위 지정이 가능해야한다.  
   5. 다양한 오브젝트를 맵상에 올릴 수 있어야 한다.  
   6. 오브젝트는 배율 축소 확대에 따라 함께 축소 확대 되거나 오브젝트 크기는 배율에 맞게 재조정되어 유지할 수 있어야 한다.  
   7. 자체적으로 오브젝트를 등록할 수 있어야 한다.  
   8. 오브젝트가 외부의 이벤트에 대응하여 반응할 수  있어야 한다.  
   9. 일반지도와 위성지도를 선택 변경 할 수 있어야 한다.  
<hr>

<br>
<br>

#### Update Date: 2023/02/24  

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

#### Update Date: 2023/02/27  

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

#### Update Date: 2023/02/28  

* Version : v1.0.0  

* 개발 내역  


      1) GMap.Net의 기능중 Offline활용이 가능한 부분을 확인하기 위해 테스트를 진행하였다.  오프라인에서 사용하기 위해서는 gmdb의 파일을 만들어서 importing하는 작업이 필요하다.  
        a) 먼저 MapProvider에서 제공하는 지도의 종류를 선택한다.  
        b) 원하는 위치에서 Alt+LeftMouseButton을 하고, 저장하고자 하는 지도의 공간을 선택한다.   
        c) Prefetch 버튼을 클릭하여 저장한다. (단, 여러차례 Zoom 레벨에 맞게 지도 파일을 구성하는 작업을 한다. 최대 Zoom = 22 까지 진행하면, 작은 구역을 선택해도 몇 만개의 Textile 파일을 구성해서 저장하게 될 수 있다.)  
        d) 마지막으로 반드시 파일을 Import 해줘야 한다. 이렇게 하면, Offline 환경에서도 지도파일을 불러와 GMap.Net 라이브러리에서 동작을 시킬 수 있다.  
      2) GMapControl을 자체 CustomControl로 변경하여 작업을 하고자 하였으나, 기존에 구성하고 있던 FrameworkElement의 필수 구성요소가 충족되지 않아 만들지 못했다.  
      3) CustomControl에 GMapControl만 Wrapping하려고 하였으나 지도가 나타나지 않는 문제가 발행하였다.  
    
<hr>

#### Update Date: 2023/03/02  

* Version : v1.0.0  

* 개발 내역  

      1) 개발을 위한 요구사항 정리하였다.  
      2) Caliburn.Micro Mvvm Framework 적용하였다.  
      3) Ironwall 개발 Framework 적용하였다.  
      4) MapViewModel로 ContentControl 적용을 통한 MVVM 구현하였다.  