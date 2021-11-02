#  MiniGolf VR

We created a virtual reality game using Unity, as part of a school project. The game is intended for the Occulus Quest, and has only be tested on it.

[Download the demo](https://github.com/mmeyrat/MiniGolf-VR/releases/tag/Demo)

## Contribution Standards

Formatting is super importand and is hard to be consistent. Please use the below formatting (or at least try as much as you can)

-Please use the camel case with the initial character lower case for variables. For example:
isTextDisplayed = good
IsTextDisplayed = bad
is_text_dispayed = bad

-Use camel case with initial character upper case for functions. For example:
FixedUpdate() = good
fixedUpdate() = bad
fixed_update() = bad

-Use wrap around curly brackets when using functions. For example:
FixedUpdate(){  = Good
    ....
}

FixedUpdate(){ ... } = Bad

FixedUpdate() = Bad
{ 
    ... 
}

Also try and keep sections of code arranged without returns, unless it makes sense to break it up. Please use one tab or 4 spaces when indenting and please try and keep functions ending curly bracket in line with the calling 'if' statement. If there is many if statements, to make it easier to scan through the code, please do it like this:

if(...){
    if(...){
        ...
    }
    if(...){
        ...
    }
}
if(...){
    ...
}
if(...){
    ...
}

Finally, please do not use magic numbers (ie. hard coded integers / floats). Please make them public so other programmers can easily change them. For example:

public class Rotor : MonoBehaviour

## Code of Conduct

Be respectful to other contributors as well as moderators. No disrespectful comments regarding race, religious preference, sexual orientation, gender identity, military status or age will be tolerated. Any violation of the previously mentioned terms can result in being banned from any further contributing to this project. Please follow the contribution standards (above) when contributing or your contribution may be rejected with a comment to "please change your contribution to follow the contribution standards."

## Description

The player is immersed in a mini-golf field containing a 3-hole course, and some vegetation. Once equipped with the golf club, the player can go hit the ball and overcome the obstacles. 

At the begining of the game, a golf club is available on the left. To make a stroke, the player simply adjust the power of the club, point the ball in the desired direction and then hit the ball with the club.

The first hole is a simple angle, the second one contains a jump with a springboard, and for the third hole, the ball has to pass through a windmill without touching the wings. When the player makes a successful stroke, the ball is automatically teleported to the next hole. 

Cubes are positioned on the course and increase the score if they are hit by the ball.

## Controls

- A : adjust the ball direction.
- B : reset the ball to its initial position on the current hole.
- Y : toggle interface.
- Right grip : catch the club with the right hand. 
- Left grip : catch the club with the left hand. 
- Right joystick : move the camera.
- Left joystick : move the player.
- Right trigger : increase the club's power.
- Left trigger : decrease the club's power.

## Video

[![Overview video](https://img.youtube.com/vi/4oa6d6kKAao/0.jpg)](https://www.youtube.com/watch?v=4oa6d6kKAao)

----

Dumonteil Maxime & Meyrat Maxime
