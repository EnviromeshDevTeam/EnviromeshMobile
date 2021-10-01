using GreenHouse.Models;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace GreenHouse.Backend
{
    public class GraphHandler
    {
        public DeviceDataFetch DataObj { get; set; } = new DeviceDataFetch();

        public List<List<ChartEntry>> GraphReadyData { get; set; } = new List<List<ChartEntry>>();

        public Device unprocessedDeviceData { get; set; } = new Device();


        //Call Refresh On creation?
        public GraphHandler()
        {

        }

        //TODO: Replace string switch with enum?
        //enum _timeScales
        //{
        //    _1H = 1,
        //    _4H = 4,
        //    _12H = 12,
        //    _24H = 24,
        //    _6D = 144,
        //    _30D = 720
        //}
        //_timeScales currScale = _timeScales._1H;

        /// <summary>
        /// Only grab Device level of data here because that is given from Devices selection page
        /// </summary>
        ///
        public async Task AsyncRefreshFromApi(int _deviceNum)
        {
            RootClass tempRootReturn = await DataObj.APIFetchAsync();
            unprocessedDeviceData = tempRootReturn.Devices[_deviceNum - 1];
        }

        public void ReturnAllChartPlots(string _timeScale)
        {
            List<ChartEntry> processed_TempData = unprocessedDeviceData.Temperature.ReturnPlotPoints(_timeScale);
            GraphReadyData.Clear();

            GraphReadyData.Add(processed_TempData);

            List<ChartEntry> processed_HumiData = unprocessedDeviceData.Humidity.ReturnPlotPoints(_timeScale);
            GraphReadyData.Add(processed_HumiData);

            List<ChartEntry> processed_CO2Data = unprocessedDeviceData.CO2.ReturnPlotPoints(_timeScale);
            GraphReadyData.Add(processed_CO2Data);

            List<ChartEntry> processed_TVOCData = unprocessedDeviceData.TVOC.ReturnPlotPoints(_timeScale);
            GraphReadyData.Add(processed_TVOCData);

            List<ChartEntry> processed_MoistureData = unprocessedDeviceData.Moisture.ReturnPlotPoints(_timeScale);
            GraphReadyData.Add(processed_MoistureData);
        }
    }
}
