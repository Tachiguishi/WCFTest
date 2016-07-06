### 1. 构建数据库
使用DB2数据库，数据库表格创建：
```sql
CREATE TABLE PDMS.PERSON(
  USER_ID VARCHAR(16) NOT NULL,     --用户ID,登录名，唯一标识
  USER_NAME VARCHAR(32) NOT NULL,   --用户昵称(用于显示)
  PASSWORD VARCHAR(64) NOT NULL,    --用户登录密码
  BIRTHDAY TIMESTAMP,               --生日
  GENDER INTEGER,                   --1:男，0:女
  EMAIL VARCHAR(128),
  PHONE VARCHAR(16),
  PRIMARY KEY(USER_ID)
)
```

### 2. 构建实体对象
```C#
public class iPerson
{
    public string UserID { set; get; }

    public string UserName { set; get; }

    public string Password {set; get;}

    public DateTime Birthday {set; get;}

    public int Gender {set; get;}

    public string Email {set; get;}

    public string Phone {set; get;}
}
```

### 3. sql语句
```sql
<?xml version="1.0" encoding="utf-8" ?>
<sqlMap namespace="PersonSQL" xmlns="http://ibatis.apache.org/mapping" xmlns:xls="http://www.w3.org/2001/XMLSchema-instance">
  <alias>
    <!-- alias:是别名，type:[命名空间.类名,命名空间] -->
    <typeAlias alias="Person" type="iBatisDomain.iPerson,iBatisDomain" />
  </alias>
  <resultMaps>
    <resultMap id="PersonMap" class="Person">
      <result property="UserID" column="USER_ID"/>
      <result property="UserName" column="USER_NAME"/>
      <result property="Password" column="PASSWORD"/>
      <result property="Birthday" column="BIRTHDAY"/>
      <result property="Gender" column="GENDER"/>
      <result property="Email" column="EMAIL"/>
      <result property="Phone" column="PHONE"/>
    </resultMap>
  </resultMaps>
  <statements>
    <select id="query" parameterClass="Person" resultMap="PersonMap">
      SELECT * FROM PDMS.person
      <isNotEmpty property="UserID">
      WHERE USER_ID = #UserID#
      </isNotEmpty>
    </select>
    <select id="query2" parameterClass="Person" resultClass="Person">
      SELECT
      USER_ID   as "UserID",
      USER_NAME as "UserName",
      PASSWORD  as "Password",
      BIRTHDAY  as "Birthday",
      GENDER    as "Gender",
      Email     as "Email",
      PHONE     as "Phone"
      FROM PDMS.person
      <isNotEmpty property="UserID">
      WHERE USER_ID = #UserID#
      </isNotEmpty>
    </select>
    <!-- <insert id="insert" parameterClass="Person">
      INSERT INTO PDMS.person (ID,NAME)
      VALUES  (#Id#,#Name#)
    </insert> -->
  </statements>
</sqlMap>
```
`query`和`query2`只在返回结果方式上有差异  
使用`resultClass`时查询的字段要和类对象的成员变量匹配，所以需要用到别名

### 4. 调用
```C#
iPerson person = new iPerson();
IList<iPerson> ListPerson = mapper.QueryForList<iPerson>("PersonSQL.query", person);
```
