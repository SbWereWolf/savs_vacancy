using System;
using System.Collections.Generic;

namespace DuckMigrationBL
{
    public class BusinessLogic
    {
        private string _roadMap;

        const int lakeIndex = 0;
        const int roadIndex = 1;
        public BusinessLogic( string roadMap)
        {
            this._roadMap = roadMap;
        }
        public string CalculatePathMap()
        {
            string[] lakesRoad = null;
            if (_roadMap != null)
            {
                lakesRoad = _roadMap.Split(new[ ] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            }

            var isExists = lakesRoad != null;
            var roadMapSize = 0;
            if (isExists)
            {
                roadMapSize = lakesRoad.Length;
            }

            isExists = roadMapSize > 1;
            var basis = string.Empty;
            var finish = string.Empty;
            if (isExists)
            {
                basis = lakesRoad[0];
                finish = lakesRoad[roadMapSize - 1];
            }

            int lakesCount;
            int startRoadCount;
            var isStartPointValid = GetLakeRoads(basis, out lakesCount, out startRoadCount);

            var finishPointExists = !string.IsNullOrWhiteSpace(finish);
            string[] finishPoint = null;
            if (finishPointExists)
            {
                finishPoint = finish.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var isFinishPointValid = finishPoint != null && finishPoint.Length == 1;
            var finishLakesCount = 0;
            if (isFinishPointValid)
            {
                var finishCountSuccess = int.TryParse(finishPoint[lakeIndex], out finishLakesCount);
            }



            var isFinishValid = finishLakesCount == 1;
            var isStartValid = lakesCount > 0 && startRoadCount >= 0 && lakesCount > startRoadCount;
            var result =
                "Данные имеют не верный формат,"
                + " в первой строке должно быть положительное число озёр и не отрицательное число дорог, "
                + "число озёр должно быть больше числа дорог, "
                + "в последней строке должна быть единица";
            var pathMap = new List<int>();
            var letCalculate = false;
            if (isStartValid && isFinishValid)
            {
                result = string.Empty;
                var path = lakesCount - startRoadCount;
                pathMap.Add(path);
                letCalculate = roadMapSize>2;
            }

            if (letCalculate)
            {
                for (var index = 1; index < roadMapSize-1; index++)
                {
                    var lakeNumber = 0;
                    var roadNumber = 0;
                    var path = -1;
                    var isMapRecordValid = GetLakeRoads(lakesRoad[index], out lakeNumber, out roadNumber);
                    var isPathRecordValid = isMapRecordValid && lakeNumber == 1; 
                    if (isPathRecordValid)
                    {
                        path = lakesCount - roadNumber;
                    }
                    pathMap.Add(path);
                }
            }

            var stringIndex = 0;
            foreach (var path in pathMap)
            {
                stringIndex++;
                var part = path.ToString();
                if (path < 0 )
                {
                    part = $"(ошибка формата записи для строки {stringIndex})";
                }
                result += $"{part} ";
                
            }

            return result;
        }

        private static bool GetLakeRoads(string roadsRecord, out int lakesCount, out int roadCount)
        {
            var isStartExists = !string.IsNullOrWhiteSpace(roadsRecord);
            string[] mapPoint = null;
            if (isStartExists)
            {
                mapPoint = roadsRecord.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            }

            var isPointValid = mapPoint != null && mapPoint.Length == 2;

            lakesCount = 0;
            roadCount = 0;
            var countSuccess = false;
            var roadSuccess = false;
            if (isPointValid)
            {
                countSuccess = int.TryParse(mapPoint[lakeIndex], out lakesCount);
                roadSuccess = int.TryParse(mapPoint[roadIndex], out roadCount);
            }

            var result = isPointValid && countSuccess && roadSuccess;

            return result;
        }
    }
}
