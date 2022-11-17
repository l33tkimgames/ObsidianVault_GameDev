--------
# Color
### 1. Add Color
```markdown
<span style="color:colorname;">text</span>
```

|  | |
| ----------- | ----------- | ----------- | 
| <span style="color:powderblue;">powderblue</span> | <span style="color:aqua;">aqua</span> | <span style="color:aquamarine;">aquamarine</span> |
| <span style="color:cadetblue;">azure</span> | <span style="color:RoyalBlue;">RoyalBlue</span> |<span style="color:SteelBlue;">SteelBlue</span> |
| <span style="color:HotPink;">HotPink</span> | <span style="color:DarkSalmon;">DarkSalmon</span> | <span style="color:blueviolet;">blueviolet</span> | <span style="color:Plum;">Plum</span> |
| <span style="color:tomato;">tomato</span> | <span style="color:FireBrick;">FireBrick</span> |<span style="color:Orange;">Orange</span> |
| <span style="color:Gold;">Gold</span> | <span style="color:chocolate;">chocolate</span> | <span style="color:burlywood;">burlywood</span> |
| <span style="color:SaddleBrown;">SaddleBrown</span>| <span style="color:YellowGreen;">YellowGreen</span> | <span style="color:DarkOliveGreen;">DarkOliveGreen</span> |
| <span style="color:Lime;">Lime</span> | <span style="color:LightGreen;">LightGreen</span> | <span style="color:DimGray;">DimGray</span> |

### 2. Color & Bold
```markdown
<strong><span style="color:colorname;">text</span></strong>
```

### 3. Color & Custom Size
<span style="font-size:50px;">I am big</span>

---

# Table

```
|  | |
| ----------- | ----------- | 
```

------------------

# Header 1
## Header 2
### Header 3
#### Header 4

__________________

# Formatting

_italics1_
*italics2*

**Bold**

`comment inline`
```c
int codeblock = 1;
// Codeblock
int main() {
	return 0;
}
```

------------------

# HTML STYLE

<h1 style="font-family:verdana;">This is a heading</h1>  
<p style="font-family:courier;">This is a paragraph.</p>
<h1 style="font-family:verdana;">This is a heading</h1>  
<p style="font-family:courier;">This is a paragraph.</p> 

---

# Plugin Pictures

One approach, that appears to be relatively markdown friendly, could be to place attributes in the currently unused pretty link position.

![[graphic.png|{width=50%}]]
Or just recognize that something like curly braces contain attributes

![[graphic.png{width=50%}]]
Alt text could be supported like this

![[graphic.png{width=50%}|alt-text]]
I’m linking this because it’s related and seems like pandoc has a reasonable approach, with the potential for additional utility

![[caption text]](graphic.png){width=50%}
or

![[graphic.png]]{width=50%}
This approach could easily allow alt-text

![[graphic.png|alt-text]]{width=50%}

As another option, I’ve seen something like this in the forums somewhere also.
![[<img  width="80px">graphic.png]]

---

