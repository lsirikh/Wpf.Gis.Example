# GMAP.NET GIS Map Test

### Goal
> Ironwall에 적용하기 위한 MAP을 GIS 서비스를 활용한 MAP을 제공하도록 한다.

<hr>
### Update Date: 2023/02/27  
* Version : v1.0.0  

* 추가 기능  
    1) 가장 기본적인 BaseLine을 구현하였다.  
    2) GMAP.NET시리즈를 Nuget Import하였다.  
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

    3) Symbol에 사용되는 기본적인 CustomControl을 구성하여 Gis Map상 오브젝트로 설정하였다.  
    4) 맵의 Scale에 따라 ProgressBar를 연동하여 데이터 변동을 확인하였다. (일부 버그가 확인되어 디버깅이 필요함.)  

<hr>
