#include<stdlib.h>

const int inicio_pacote = 0xAA;
const int fim_pacote = 0xBB;
unsigned int leitura_pontos_ad = 0;
char valor_pressao[10];
float pressao_psi = 0;
float leitura_tensao = 0;
void setup() {
  Serial.begin(9600); 
}

void loop() {
  delay(500);
  leitura_pontos_ad = analogRead(A0);
  leitura_tensao = ((float)leitura_pontos_ad*5.0)/1023.0;
  pressao_psi = 125.0 * (leitura_tensao - 0.5);   
  dtostrf(pressao_psi,6,2,valor_pressao);
    //Serial.println(inicio_pacote);
    //Serial.println(leitura_pontos_ad);
    //Serial.println(leitura_tensao);
    Serial.println(pressao_psi);
    //Serial.println(fim_pacote);
    leitura_tensao = 0;
    leitura_pontos_ad = 0;
    pressao_psi = 0;
}
