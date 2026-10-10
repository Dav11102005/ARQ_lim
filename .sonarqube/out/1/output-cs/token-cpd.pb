À
WC:\Users\Windows\Downloads\ARQ_lim_nuevo\src\Application\Validators\ProductValidator.cs
	namespace 	
Application
 
. 

Validators  
;  !
public 
static 
class 
ProductValidator $
{ 
public 

static 
void 
Validate 
(   
CreateProductRequest  4
request5 <
)< =
{ !
ArgumentNullException		 
.		 
ThrowIfNull		 )
(		) *
request		* 1
)		1 2
;		2 3
if 

( 
string 
. 
IsNullOrWhiteSpace %
(% &
request& -
.- .
Name. 2
)2 3
)3 4
{ 	
throw 
new 
ArgumentException '
(' (
$str( P
,P Q
nameofR X
(X Y
requestY `
)` a
)a b
;b c
} 	
if 

( 
request 
. 
Price 
<= 
$num 
) 
{ 	
throw 
new '
ArgumentOutOfRangeException 1
(1 2
nameof2 8
(8 9
request9 @
)@ A
,A B
$strC g
)g h
;h i
} 	
} 
} ô 
SC:\Users\Windows\Downloads\ARQ_lim_nuevo\src\Application\Services\ProductService.cs
	namespace 	
Application
 
. 
Services 
; 
public		 
class		 
ProductService		 
:		 
IProductService		 -
{

 
private 
readonly 
IProductRepository '
_productRepository( :
;: ;
public 

ProductService 
( 
IProductRepository ,
productRepository- >
)> ?
{ 
_productRepository 
= 
productRepository .
??/ 1
throw2 7
new8 ;!
ArgumentNullException< Q
(Q R
nameofR X
(X Y
productRepositoryY j
)j k
)k l
;l m
} 
public 

async 
Task 
< 
IEnumerable !
<! "

ProductDto" ,
>, -
>- .
GetAllAsync/ :
(: ;
); <
{ 
var 
products 
= 
await 
_productRepository /
./ 0
GetAllAsync0 ;
(; <
)< =
;= >
return 
products 
. 
Select 
( 
MapToDto '
)' (
;( )
} 
public 

async 
Task 
< 

ProductDto  
?  !
>! "
GetByIdAsync# /
(/ 0
Guid0 4
id5 7
)7 8
{ 
var 
product 
= 
await 
_productRepository .
.. /
GetByIdAsync/ ;
(; <
id< >
)> ?
;? @
return 
product 
is 
null 
?  
null! %
:& '
MapToDto( 0
(0 1
product1 8
)8 9
;9 :
} 
public 

async 
Task 
< 

ProductDto  
>  !
CreateAsync" -
(- . 
CreateProductRequest. B
requestC J
)J K
{ 
ProductValidator   
.   
Validate   !
(  ! "
request  " )
)  ) *
;  * +
var"" 
product"" 
="" 
new"" 
Product"" !
{## 	
Name$$ 
=$$ 
request$$ 
.$$ 
Name$$ 
.$$  
Trim$$  $
($$$ %
)$$% &
,$$& '
Description%% 
=%% 
request%% !
.%%! "
Description%%" -
.%%- .
Trim%%. 2
(%%2 3
)%%3 4
,%%4 5
Price&& 
=&& 
request&& 
.&& 
Price&& !
}'' 	
;''	 

var)) 
createdProduct)) 
=)) 
await)) "
_productRepository))# 5
.))5 6
AddAsync))6 >
())> ?
product))? F
)))F G
;))G H
return** 
MapToDto** 
(** 
createdProduct** &
)**& '
;**' (
}++ 
private-- 
static-- 

ProductDto-- 
MapToDto-- &
(--& '
Product--' .
product--/ 6
)--6 7
{.. !
ArgumentNullException// 
.// 
ThrowIfNull// )
(//) *
product//* 1
)//1 2
;//2 3
return11 
new11 

ProductDto11 
(11 
product22 
.22 
Id22 
,22 
product33 
.33 
Name33 
,33 
product44 
.44 
Description44 
,44  
product55 
.55 
Price55 
,55 
product66 
.66 
CreatedAtUtc66  
)66  !
;66! "
}77 
}88 ©
OC:\Users\Windows\Downloads\ARQ_lim_nuevo\src\Application\Services\Calculator.cs
	namespace 	
Application
 
. 
Services 
; 
public 
static 
class 

Calculator 
{ 
public 

static 
int 
Add 
( 
int 
a 
,  
int! $
b% &
)& '
=>( *
a+ ,
+- .
b/ 0
;0 1
public 

static 
int 
Subtract 
( 
int "
a# $
,$ %
int& )
b* +
)+ ,
=>- /
a0 1
-2 3
b4 5
;5 6
} æ
VC:\Users\Windows\Downloads\ARQ_lim_nuevo\src\Application\Interfaces\IProductService.cs
	namespace 	
Application
 
. 

Interfaces  
;  !
public 
	interface 
IProductService  
{ 
Task 
< 	
IEnumerable	 
< 

ProductDto 
>  
>  !
GetAllAsync" -
(- .
). /
;/ 0
Task 
< 	

ProductDto	 
? 
> 
GetByIdAsync "
(" #
Guid# '
id( *
)* +
;+ ,
Task		 
<		 	

ProductDto			 
>		 
CreateAsync		  
(		  ! 
CreateProductRequest		! 5
request		6 =
)		= >
;		> ?
}

 Õ
KC:\Users\Windows\Downloads\ARQ_lim_nuevo\src\Application\DTOs\ProductDto.cs
	namespace 	
Application
 
. 
DTOs 
; 
public 
sealed 
record 

ProductDto 
(  
Guid 
Id	 
, 
string 

Name 
, 
string 

Description 
, 
decimal 
Price 
, 
DateTime 
CreatedAtUtc 
) 
; 
public

 
sealed

 
record

  
CreateProductRequest

 )
(

) *
string 

Name 
, 
string 

Description 
, 
decimal 
Price 
) 
; 