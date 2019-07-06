		/* ************ Command to TUNER ***************************************************************** */
        /*                                                                                                 */
        /*      x = Start Tuner                                                                            */
        /*      Y – audio volume scaler                                                                    */
        /*          Y0 – mute                                                                              */
        /*          .............                                                                          */
        /*          Y100 – set highest volume                                                              */
        /*      Q – squelch threshold level                                                                */
        /*          Q0 – squelch off                                                                       */
        /*          Q10 – squelch at 10dBf                                                                 */
        /*          Q-1 – stereo squelch                                                                   */
        /*                                                                                                 */
        /*      M – demodulation mode                                                                      */
        /*          M0 – FM                                                                                */
        /*          M1 – AM                                                                                */
        /*      T – tune to a frequency [kHz]                                                              */
        /*          T87500 – tune at 87.500 MHz                                                            */
        /*      A – AGC threshold level                                                                    */
        /*          A0 – highest                                                                           */
        /*          A1 – high                                                                              */
        /*          A2 – medium                                                                            */
        /*          A3 – low                                                                               */
        /*      F – IF digital filter bandwidth (0-15 FM, 16-30 AM, negative number – adaptive bandwidth)  */
        /*          F15 – set the widest FM filter bandwidth                                               */
        /*          F-1 – set adaptive bandwidth                                                           */
        /*      D – de-emphasis mode                                                                       */
        /*          D0 – 50µs                                                                              */
        /*          D1 – 75µs                                                                              */
        /*          D2 – off                                                                               */
        /*                                                                                                 */
        /*      G – RF/IF gain                                                                             */
        /*          G00 – RF and IF normal gain                                                            */
        /*          G10 – RF +6dB gain                                                                     */
        /*          G01 – IF +6dB gain                                                                     */
        /*          G11 – RF and IF +6dB gain                                                              */                             
        /*      Z – antenna switch                                                                         */
        /*          Z0 – set high state on digital pin 8                                                   */
        /*          Z1 – set high state on digital pin 9                                                   */
        /*          Z2 – set high state on digital pin 10                                                  */
        /*          Z3 – set high state on digital pin 11                                                  */                                      
        /*                                                                                                 */
        /*                                                                                                 */
        /*                                                                                                 */
        /*                                                                                                 */
        /*      X = Stop Tuner                                                                             */
        /*                                                                                                 */
        /* ************ Command to TUNER ***************************************************************** */



        /* *************** Commands from TUNER **************************************************** */
        /*              x: OK\n                                            							*/
        /*              Y (tuner volume):                                  							*/
        /*               example: Y100 -> Y100 (tuner volume 100)          							*/
        /*              Q (Tuner Squelch):                                 							*/
        /*               example: Q10 -> Q10 (squelch at 10dBf)            							*/
        /*              M (demodulation mode):                             							*/
        /*               example: M0 -> M0 (FM)                            							*/
        /*               example: M1 -> M1 (AM)                            							*/
        /*              T (AGC threshold level):                           							*/
        /*               NO RESPONSE                                       							*/
        /*                                                                 							*/
        /*              D (de-emphasis mode):                              							*/
        /*                example: D0 -> D0 (50µs)                         							*/
        /*                example: D1 -> D1 (75µs)                         							*/
        /*                example: D2 -> D2 (off)                          							*/
        /*             G: (RF/IF Gain):                                    							*/
        /*                       Serial.print('G');                        							*/
        /*              if(buff[1] == '1')                                 							*/
        /*              {                                                  							*/
        /*                  CONTROL |= B10000000; /* FM RF +6dB gain       							*/
        /*                  Serial.print('1');                             							*/
        /*              }                                                  							*/
        /*              else                                               							*/
        /*              {                                                  							*/
        /*                  CONTROL &= B01111111; /* FM RF standard gain   							*/
        /*                  Serial.print('0');                             							*/
        /*              }                                                  							*/
        /*              if(buff[2] == '1')                                 							*/
        /*              {                                                  							*/
        /*                  CONTROL |= B00010000; /* IF +6dB gain          							*/
        /*                  Serial.print('1');                             							*/
        /*              }                                                  							*/
        /*              else                                               							*/
        /*              {                                                  							*/
        /*                  CONTROL &= B11101111; /* IF standard gain      							*/
        /*                  Serial.print('0');                             							*/
        /*              }                                                  							*/
        /*              Serial.print('\n');                                							*/      
        /*                                                                 							*/
        /*                                                                 							*/
        /*              IF (digital filter bandwidth);                     							*/
        /*                 F15 -> F15 = 309 Khz                            							*/
        /*                 F4 -> F4 = 125 Khz                            							*/
        /*     		F-1 = Adaptive Bandwith (but will use 120khz here since no algo in SDR# yet :(  */                            							
        /*                                                                 							*/
        /*                                                                 							*/
        /*                                                                 							*/
        /*                                                                 							*/
        /*                                                                 							*/
        /*              X: OK\n                                            							*/
        /*                                                                 							*/
        /*              //THIS IS WHAT TUNER SENDS ALL THE TIME            							*/
        /*              S (Signal)                                         							*/
        /*                s50,10,100 = Stereo, Signal 50db, Multipath 10, ACI 100db                 */
        /*                S50,10,100 = Forced Stereo, Signal 50db, Multipath 10, ACI 100db			*/
        /*                m50,10,100 = Mono, Signal 50db, Multipath 10, ACI 100db 					*/
        /*                                                                 							*/
        /*                                                                 							*/
        /*                                                                 							*/
        /*                                                                 							*/
        /*                                                                 							*/
        /*                                                                 							*/
        /* *************** Commands from TUNER **************************************************** */