<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="CarRentalCloudService" generation="1" functional="0" release="0" Id="9b2237eb-bbd9-439f-bf84-563237c9d46b" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="CarRentalCloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="CarRentalWebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/LB:CarRentalWebRole:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="CarRentalWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/MapCarRentalWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="CarRentalWebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/MapCarRentalWebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:CarRentalWebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/CarRentalWebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapCarRentalWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/CarRentalWebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapCarRentalWebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/CarRentalWebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="CarRentalWebRole" generation="1" functional="0" release="0" software="D:\Depot\Tesco\guide\CarRentalCloudService\CarRentalCloudService\csx\Debug\roles\CarRentalWebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;CarRentalWebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;CarRentalWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/CarRentalWebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/CarRentalWebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/CarRentalWebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="CarRentalWebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="CarRentalWebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="CarRentalWebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="e544f7a9-219b-48fc-9d4e-ada6b9d793a2" ref="Microsoft.RedDog.Contract\ServiceContract\CarRentalCloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="da7b520d-5b60-41ab-84bb-6ee5a71a1e60" ref="Microsoft.RedDog.Contract\Interface\CarRentalWebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/CarRentalCloudService/CarRentalCloudServiceGroup/CarRentalWebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>