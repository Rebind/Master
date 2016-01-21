class ball (int x, int y,objSprite sprite) {
    int bx;
    int by;
    objSprite bsprite;

    void show(int x, int y, objSprite sprite){
      //show ball on the screen
    }

    void draw(ball aball){
      int getObjx = aball.bx;
      int getObjy = aball.by;
      objSprite getObjSprite = aball.bspriite;
      show(getObjx, getObjy, getObjSprite);
    }

    void handle(containerOfBalls){
      for each element in containerOfBalls do {
        draw (element);
      }
    }
}

int main(){
    //push object balls to the container
    for ball want to show on the scrren{
      containerOfBalls.push(ball);
    }
    ball.handle(containerOfBalls);

    return 0;
}