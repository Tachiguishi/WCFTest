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
